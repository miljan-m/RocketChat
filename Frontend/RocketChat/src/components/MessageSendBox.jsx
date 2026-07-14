import React from 'react'
import '../Styles/MessageSendBox.css'
import AttachFileIcon from '@mui/icons-material/AttachFile';
import SendIcon from '@mui/icons-material/Send';

const MessageSendBox = () => {
  return (
    <div className="message-send-box-wrapper" >
      <textarea name="" id="" placeholder='Message...'></textarea>
      <div className="attachment-sendbutton-div">
        <AttachFileIcon color='primary' />
        <SendIcon color='primary' />
      </div>

    </div>
  )
}

export default MessageSendBox