import * as React from 'react';

export default function Catalog() {
    const [forecasts, setForecasts] = React.useState(null)
    const [loading, setLoading] = React.useState(true)
    React.useEffect(() => {
        populateWeatherData(setForecasts, setLoading)
    }, [])
    let contents = loading ? <p><em>Loading...</em></p> : <p><em>Loadead</em></p>;
    return (
        <React.Fragment>
            <h1>Catalog</h1>
            <div>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        </React.Fragment>
    )
}

async function populateWeatherData(setForecasts: Function, setLoading: Function) {
    const response = await fetch('hello');
    const data = await response.json();
    setLoading(false);
    setForecasts(data);
}