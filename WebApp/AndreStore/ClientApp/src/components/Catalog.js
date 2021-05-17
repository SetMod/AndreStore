"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
function Catalog() {
    var _a = React.useState(null), forecasts = _a[0], setForecasts = _a[1];
    var _b = React.useState(true), loading = _b[0], setLoading = _b[1];
    populateWeatherData(setForecasts, setLoading);
    var contents = loading ? React.createElement("p", null,
        React.createElement("em", null, "Loading...")) : forecasts;
    return (React.createElement(React.Fragment, null,
        React.createElement("h1", null, "Catalog"),
        React.createElement("div", null,
            React.createElement("p", null, "This component demonstrates fetching data from the server."),
            contents)));
}
exports.default = Catalog;
function populateWeatherData(setForecasts, setLoading) {
    fetch('hello')
        .then(function (response) {
        setLoading(false);
        var data = response.json();
        console.log();
        data.then(function (data) { return setForecasts({ id: data.body.id, price: data.price, deliveryId: 2, description: "Very cool old smartphone with small baery life", name: "Samsung S2", imagePath: "img/sqmsung-s2.png", category: "Smartphones", amount: 1 }); });
    });
}
//# sourceMappingURL=Catalog.js.map