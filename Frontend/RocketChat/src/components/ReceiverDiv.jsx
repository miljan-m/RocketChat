import React, { useState } from 'react'
import '../Styles/ReceiverDiv.css'
import Avatar from '@mui/material/Avatar'
import MoreVertIcon from '@mui/icons-material/MoreVert';
import DeleteIcon from '@mui/icons-material/Delete';
import ArchiveIcon from '@mui/icons-material/Archive';

const ReceiverDiv = ({ receiver, handleDeleteConversation }) => {
    const [isOpen, setIsOpen] = useState(false)

    return (

        receiver && (<div className="receiver-div-wrapper">
            {isOpen &&
                <div className="options-div">
                    <button onClick={() => handleDeleteConversation()}><DeleteIcon color='primary' />Delete</button>
                    <button><ArchiveIcon color='primary' />Archive</button>
                </div>
            }
            <button id='option-btn' style={{ "border": "none" }} onClick={() => setIsOpen(!isOpen)}><MoreVertIcon color='primary' /></button>
            <div className="right-side-div">
                < span > {receiver.userName}</span >
                <Avatar style={{ cursor: 'pointer' }}>{receiver.userName.charAt(0)}</Avatar>
            </div>
        </div >)


    )
}

export default ReceiverDiv