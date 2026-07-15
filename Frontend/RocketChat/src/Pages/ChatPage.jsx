import React, { use, useContext, useEffect, useState } from 'react'
import ContactList from '../components/ContactList'
import ReceiverDiv from '../components/ReceiverDiv'
import MessageSendBox from '../components/MessageSendBox'
import Conversation from '../components/Conversation'
import '../Styles/ChatPage.css'
import { HubConnectionBuilder } from '@microsoft/signalr'
import {LoginContext} from '../Context/LoginContext'

const ChatPage = () => {
  const [connection, setConnection] = useState()
  const [receiverUsername, setReceiverUsername] = useState()
  const baseUrl = import.meta.env.VITE_API_BASE_URL;
  const { user, HandleLogin } = useContext(LoginContext)

  useEffect(() => {

    const newConnection = new HubConnectionBuilder()
      .withUrl(`${baseUrl}/chat`, {
        accessTokenFactory: () => localStorage.getItem('accessToken')
      })
      .withAutomaticReconnect()
      .build()

    setConnection(newConnection)

  }, [])

  useEffect(() => {

    if (connection) connection.start().then(() => {
      connection.on("ReceivePrivateMessage", (message) => {
        console.log(message)
      })
    })

  }, [connection])

  const SendMessage = async (message, username) => {
    try {
      await connection.invoke("SendMessage", message, username)
    } catch (error) {
      console.log(error)
    }
  }

  return (
    <div className="chat-wrapper">
      <ContactList />
      <div className="conversation-div">
        <ReceiverDiv />
        <Conversation />
        <MessageSendBox sendMessage={SendMessage} />
      </div>
    </div>
  )
}
export default ChatPage