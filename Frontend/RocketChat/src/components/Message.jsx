import Avatar from '@mui/material/Avatar'
import React, { useContext, useEffect, useState } from 'react'
import '../Styles/Message.css'
import { LoginContext } from '../Context/LoginContext'

const Message = ({ message }) => {
    const { user } = useContext(LoginContext)
    const timeArray = message.dateTime.split("T")
    const time = timeArray[1].split(".")[0]
    const [isTimeDivOpen, setIsTimeDivOpen] = useState(false)
    return (
        (user.userName == message.receiverUsername ?
            <div className="left-message-wrapper">
                <Avatar style={{ cursor: 'pointer' }} />
                <div className='whole-message' onClick={() => setIsTimeDivOpen(!isTimeDivOpen)}>
                    {message.receiverUsername != user.userName ? message.receiverUsername : message.senderUsername}
                    <div className="message-text">
                        {
                            message.messageText
                        }
                    </div>
                    {isTimeDivOpen === true ? <span className="message-time">{time}</span> : null}
                </div>
            </div> :
            <div className="right-message-wrapper">
                <Avatar style={{ cursor: 'pointer' }} />
                <div className='whole-message' onClick={() => setIsTimeDivOpen(!isTimeDivOpen)}>
                    <div className="message-text">
                        {
                            message.messageText
                        }
                    </div>
                    {isTimeDivOpen === true ? <span className="message-time">{time}</span> : null}
                </div>
            </div>

        )

    )
}

export default Message