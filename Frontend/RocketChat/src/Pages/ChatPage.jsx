import React, { useContext, useEffect, useEffectEvent, useState } from 'react'
import ContactList from '../components/ContactList'
import ReceiverDiv from '../components/ReceiverDiv'
import MessageSendBox from '../components/MessageSendBox'
import Conversation from '../components/Conversation'
import '../Styles/ChatPage.css'
import { HubConnectionBuilder } from '@microsoft/signalr'
import { LoginContext } from '../Context/LoginContext'
import axios from 'axios'

const ChatPage = () => {
  const [connection, setConnection] = useState()
  const [receiverUsername, setReceiverUsername] = useState()
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const { user, HandleLogin } = useContext(LoginContext)
  const [receiver, setReceiver] = useState()
  const [currentMessages, setCurrentMessages] = useState([])
  const [allMessages, setAllMesages] = useState([])

  useEffect(() => {

    const newConnection = new HubConnectionBuilder()
      .withUrl(`${baseUrl}/chat`, {
        accessTokenFactory: () => localStorage.getItem('accessToken')
      })
      .withAutomaticReconnect()
      .build()

    setConnection(newConnection)
    newConnection.start()
    newConnection.on("ReceivePrivateMessage", (userIdentifier, message) => {
      fetchMessages()
    })
  }, [receiver])


  const handleDeleteConversation = async () => {
    try {
      await axios.delete(`${baseUrl}/message`,
        {
          params: {
            receiverUsername: receiver.userName,
            senderUsername: user.userName
          }
        })
        fetchMessages()
        setReceiver(null)
    } catch (error) {

    }
  }

  const fetchMessages = async () => {
    try {
      const result = await axios.get(`${baseUrl}/message`)
      const messages = result?.data || []
      setAllMesages(messages)
      if (receiver?.userName) {
        const filtered = messages.filter(
          message => (message.receiverUsername === receiver.userName || message.senderUsername === receiver.userName) &&
            (message.receiverUsername === user.userName || message.senderUsername === user.userName)
        )
        setCurrentMessages(filtered)
      }
    } catch (error) {

    }
  }

  useEffect(() => {
    fetchMessages()
  }, [receiver])


  const SendMessage = async (message, username) => {
    try {
      await connection.invoke("SendMessage", message, username, user.userName)
      fetchMessages()
    } catch (error) {
      console.log(error)
    }
  }

  return (
    <div className="chat-wrapper">
      <ContactList setReceiverUp={setReceiver} />
      <div className="conversation-div">
        <ReceiverDiv receiver={receiver} handleDeleteConversation={handleDeleteConversation} />
        <Conversation messages={currentMessages} />
        <MessageSendBox sendMessage={SendMessage} receiver={receiver} />
      </div>
    </div>
  )
}
export default ChatPage