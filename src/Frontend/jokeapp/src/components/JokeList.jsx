import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Button from 'react-bootstrap/Button';
import Cookies from 'js-cookie';

const BASE_URL = 'https://apijokeapp.azurewebsites.net/api/';
// const BASE_URL = 'https://localhost:7252/api/';
const JokeList = () => {
    const [jokes, setJokes] = useState(null); 
    const [showButtons, setShowButtons] = useState(false); 
    axios.defaults.withCredentials = true;
    const fetchData = async () => {
        try {
            const cookieValue = Cookies.get('voted_jokes');
            // axios.interceptors.request.use(function (config) {
            //     config.withCredentials = true;
            //     config.headers['Cookie'] = `voted_jokes=${cookieValue}`;
            //     return config;
            // });
            
            const response = await axios.get(`${BASE_URL}joke/get-joke?id=${cookieValue}`);
            const responseData = response.data;
            if (responseData.data !== null) {
                setJokes(responseData.data);
                setShowButtons(true);
            }  else{
                alert(responseData.message);
            }
        } catch (error) {
            console.error('Error fetching jokes:', error);
            alert("Server Error");
        }
    };

    useEffect(() => {
        fetchData(); 
    }, []);


    const handleButtonClick = async (jokeId, vote) => {
        try {
            let votedJokes = Cookies.get('voted_jokes') ? Cookies.get('voted_jokes').split(',') : [];
                
            votedJokes.push(jokeId.toString());
                Cookies.set('voted_jokes', votedJokes.join(','), { expires: 7 }); 
                const response = await axios.post(`${BASE_URL}vote/add`, { 
                    jokeId: jokeId, 
                    liked: vote, 
                });
                console.log('Vote success:', response.data);
                fetchData();
        } catch (error) {
            console.error('Error voting:', error);
            alert("Vote Error");
        }
    };
    

    const handleLikeClick = async (jokeId) => {
        await handleButtonClick(jokeId, true);
    };
    
    const handleDislikeClick = async (jokeId) => {
        await handleButtonClick(jokeId, false);
    }

    return (
        <div className="container mt-5 ">
            {jokes === null ? (
                <div className="text-center">
                <p>Loading...</p> 
                </div>
            ) : (
                <>
                    <ul className="" style={{padding:'0px 11%'}}>
                            <li key={jokes.id} className="list-group-item" dangerouslySetInnerHTML={{ __html: jokes.content }}></li>
                    </ul>
                    {showButtons && ( 
                        <div className="button-container">
                            <Button onClick={()=>handleLikeClick(jokes.id)} variant="primary">This is Funny!</Button>
                            <Button onClick={()=>handleDislikeClick(jokes.id)} variant="success">This is not Funny</Button>
                        </div>
                    )}
                </>
            )}
        </div>
    );
};

export default JokeList;
