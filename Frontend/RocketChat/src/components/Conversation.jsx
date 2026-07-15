import React from 'react'
import '../Styles/Conversation.css'
import Message from '../components/Message'
const Conversation = () => {
  var messages=[{username:'user1',message:'helo bro how are u'},{username:'user2',message:'hi buddy, ok, wbu'}]
  
  
  
  return (
    <div className="conversation-wrapper">
      {
        messages.map(message=><Message message={message}/>)
      }
    </div>
  )
}

export default Conversation