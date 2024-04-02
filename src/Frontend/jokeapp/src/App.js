import React from 'react';
import './App.css';
import Header from './components/Header';
import Content from './components/Content';
import JokeList from './components/JokeList';
import Footer from './components/Footer';

function App() {
  return (
    <div className=""> 
      <Header/>
      <Content/>
      <JokeList />
      <Footer/>
  </div>
  );
}

export default App;
