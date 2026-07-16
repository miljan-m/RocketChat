import React from 'react'
import '../Styles/Conversation.css'
import Message from '../components/Message'
const Conversation = ({ messages }) => {



  return (
    <div className="conversation-wrapper">
      {
        messages.map(message => <Message message={message} />)
      }
    </div>
  )
}

export default Conversation