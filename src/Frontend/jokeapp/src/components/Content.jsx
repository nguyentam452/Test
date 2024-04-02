import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';

function Content() {
    return (
        <Container style={{ backgroundColor: '#29b363', maxWidth:'100%', height:'200px', padding: '50px' }}>
        <Row className="justify-content-md-center">
            <Col xs={6}>
            <div style={{ color:'#ffff', textAlign: 'center' }}>
                <span style={{fontSize: '35px'}}>A joke a day keeps the doctor away</span>
                <p style={{fontSize: '14px'}}>If you joke wrong way, your teeth have to pay. (Serious)</p>
            </div>
            </Col>
        </Row>
        </Container>
    );
}

export default Content;
