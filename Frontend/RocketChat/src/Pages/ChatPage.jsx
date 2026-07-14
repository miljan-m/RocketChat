import React, { use } from 'react'
import ContactList from '../components/ContactList'
import ReceiverDiv from '../components/ReceiverDiv'
import MessageSendBox from '../components/MessageSendBox'
import Conversation from '../components/Conversation'
import '../Styles/ChatPage.css'

const ChatPage = () => {
  return (
    <div className="chat-wrapper">
      <ContactList />
      <div className="conversation-div">
        <ReceiverDiv />
        <Conversation />
        <MessageSendBox />
      </div>
    </div>
  )
}

export default ChatPage