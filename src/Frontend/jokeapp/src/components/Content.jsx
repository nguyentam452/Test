import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';

function Content() {
    return (
        <Container style={{ backgroundColor: '#29b363', maxWidth:'100%', height:'175px', padding: '4%' }}>
        <Row className="justify-content-md-center">
            <Col s={12} md={6} className="d-flex justify-content-center align-items-center">
            <div style={{ color:'#ffff', textAlign: 'center' }}>
                <span style={{fontSize: '30px'}}>A joke a day keeps the doctor away</span>
                <p style={{fontSize: '12px'}}>If you joke wrong way, your teeth have to pay. (Serious)</p>
            </div>
            </Col>
        </Row>
        </Container>
    );
}

export default Content;
