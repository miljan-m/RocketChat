import React from 'react'
import '../Styles/ReceiverDiv.css'
import Avatar from '@mui/material/Avatar'

const ReceiverDiv = ({ receiver }) => {


    return (

        receiver && (<div className="receiver-div-wrapper">
            < span > {receiver.userName}</span >
            <Avatar style={{ cursor: 'pointer' }}>{receiver.userName.charAt(0)}</Avatar>
        </div >)


    )
}

export default ReceiverDiv