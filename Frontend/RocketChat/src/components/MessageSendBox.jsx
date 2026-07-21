import React, { useState } from 'react'
import '../Styles/MessageSendBox.css'
import AttachFileIcon from '@mui/icons-material/AttachFile';
import SendIcon from '@mui/icons-material/Send';

const MessageSendBox = ({ sendMessage, receiver }) => {
  const [messageText, setMessageText] = useState('')

  const handleKeyDown = (e) => {
    if (e.key === 'Enter' && !e.shiftKey) {
      e.preventDefault()
      send()
      setMessageText("")
    }
  }
  const send = () => {
    sendMessage(messageText, receiver.userName)
    setMessageText("")
  }
  return (
    <div className="message-send-box-wrapper" >
      <textarea name="" id="textarea" value={messageText} placeholder='Message...' onChange={(e) => setMessageText(e.target.value)} onKeyDown={handleKeyDown}></textarea>
      <div className="attachment-sendbutton-div">
        <AttachFileIcon color='primary' />
        <button style={{ border: 'none' }} onClick={() => send()} >
          <SendIcon color='primary' />
        </button>
      </div>
    </div >
  )
}

export default MessageSendBox