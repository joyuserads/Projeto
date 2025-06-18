import { useState, useEffect } from 'react';
import './App.css';
import Header from '../../components/header/header';

import axios from 'axios';
import { Helmet } from 'react-helmet-async';



function App() {
  return (
    <div className="App">
    
        <Helmet>
          <title>SM - Home</title>
        </Helmet>
        <Header />

     
    </div>
  );
}

export default App;
