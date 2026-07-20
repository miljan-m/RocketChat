import Avatar from '@mui/material/Avatar'
import React, { useContext, useEffect } from 'react'
import '../Styles/Message.css'
import { LoginContext } from '../Context/LoginContext'

const Message = ({ message }) => {
    const { user } = useContext(LoginContext)

    
    return (
        (user.userName == message.receiverUsername ?
            <div className="left-message-wrapper">
                <Avatar style={{ cursor: 'pointer' }} />
                <div className='whole-message'>
                    {message.receiverUsername || message.senderUsername}
                    <div className="message-text">
                        {
                            message.messageText
                        }

                        {
                            (new Date().toLocaleTimeString())
                        }
                    </div>
                </div>
            </div> :
            <div className="right-message-wrapper">
                <Avatar style={{ cursor: 'pointer' }} />
                <div className='whole-message'>
                    <div className="message-text">
                        {
                            message.messageText
                        }

                        {
                            (new Date().toLocaleTimeString())
                        }
                    </div>
                </div>
            </div>

        )

    )
}

export default Message