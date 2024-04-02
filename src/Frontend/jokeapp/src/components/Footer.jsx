import React from 'react';

const Footer = () => {
    return (
    <footer className="footer mt-auto py-5 bg-light" style={{ borderTop: '1px solid #ccc', paddingTop: '20px', marginTop: '20px',opacity: 0.65 }}>
        <div className="container text-center">
            <span className="text-dark">
            This website is created as part of Hisolution program. The materials contained on this website are provided for general
            information only and do not constitute any form of advice. HLS assumes no resposiblity for the accuracy of any particular statement and accepts no liability for any loss
            or damage wich may anse feom reliance on the in formation contained on this site
            </span>
            <br/><br/>
            <span className="text-dark">@Copyright 2021 HLS</span>
        </div>
        </footer>
    );
};

export default Footer;