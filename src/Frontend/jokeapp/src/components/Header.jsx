import React from 'react';
import logo from '../assets/images/logo.png';
import avatar from '../assets/images/avatar.jpg';
const Header = () => {
    return (
      <nav>
      <div className="logo">
        <img src={logo} alt="" />
      </div>
      <div className="info">
        <span className="handicrafted">Handicrafted by</span>
        <span className="name">Jim HLS</span>
        <div className="avatar">
          <img src={avatar} alt="" />
        </div>
      </div>
    </nav>
    
    );
};

export default Header;