import React, { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";

function App() {
  const [weathers, setWeathers] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:7266/WeatherForecast").then((response) => {
      console.log(response);
      setWeathers(response.data);
    });
  }, []);

  return (
    <div className="App">
      <div className="container mx-auto bg-gray-200 rounded-xl shadow border p-8 m-10">
        <p className="text-3xl text-gray-700 font-bold mb-5">Welcome!</p>
        <p className="text-gray-500 text-lg">
          React and Tailwind CSS in action
        </p>
      </div>
      <header className="App-header">
        <ul>
          {weathers.map((weather: any) => (
            <li key={weather.date}>
              <div>Date : {weather.date}</div>
              <div>TemperatureC : {weather.temperatureC}</div>
              <div>TemperatureF : {weather.temperatureF}</div>
              <div>Summary : {weather.summary}</div>
            </li>
          ))}
        </ul>
      </header>
      <div className="container lg">Hello World</div>
      <div>
        <table className="table-auto border-collapse border border-spacing-2">
          <thead>
            <tr>
              <th>Song</th>
              <th>Artist</th>
              <th>Year</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>The Sliding Mr. Bones (Next Stop, Pottersville)</td>
              <td>Malcolm Lockyer</td>
              <td>1961</td>
            </tr>
            <tr>
              <td>Witchy Woman</td>
              <td>The Eagles</td>
              <td>1972</td>
            </tr>
            <tr>
              <td>Shining Star</td>
              <td>Earth, Wind, and Fire</td>
              <td>1975</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default App;
