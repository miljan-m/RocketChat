import React, { useState } from 'react'
import '../Styles/MessageSendBox.css'
import AttachFileIcon from '@mui/icons-material/AttachFile';
import SendIcon from '@mui/icons-material/Send';

const MessageSendBox = ({ sendMessage }) => {
  const [messageText, setMessageText] = useState('')
  return (
    <div className="message-send-box-wrapper" >
      <textarea name="" id="" placeholder='Message...' onChange={(e) => setMessageText(e.target.value)}></textarea>
      <div className="attachment-sendbutton-div">
        <AttachFileIcon color='primary' />
        <button style={{ border: 'none' }} onClick={() => sendMessage(messageText, "anat")}>
          <SendIcon color='primary' />
        </button>
      </div>
    </div >
  )
}

export default MessageSendBox