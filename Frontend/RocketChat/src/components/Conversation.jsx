import React, { useEffect, useRef } from 'react'
import '../Styles/Conversation.css'
import Message from '../components/Message'

const Conversation = ({ messages }) => {
  const containerRef = useRef(null)

  useEffect(() => {
    if (containerRef.current) {
      containerRef.current.scrollTop = containerRef.current.scrollHeight
    }
  }, [messages])
  return (
    <div className="conversation-wrapper" ref={containerRef}>
      {
        messages.map((message, index) => <Message key={index} message={message} />)
      }
    </div>
  )
}

export default Conversation