"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
function Catalog() {
    var _a = React.useState(null), forecasts = _a[0], setForecasts = _a[1];
    var _b = React.useState(true), loading = _b[0], setLoading = _b[1];
    //React.useEffect(() => {
    //    populateWeatherData(setForecasts, setLoading)
    //}, [])
    var contents = loading ? React.createElement("p", null,
        React.createElement("em", null, "Loading...")) : React.createElement("p", null,
        React.createElement("em", null, "Loadead"));
    return (React.createElement(React.Fragment, null,
        React.createElement("h1", null, "Catalog"),
        React.createElement("div", null,
            React.createElement("p", null, "This component demonstrates fetching data from the server."),
            contents)));
}
exports.default = Catalog;
//async function populateWeatherData(setForecasts: Function, setLoading: Function) {
//    const response = await fetch('hello');
//    const data = await response.json();
//    setLoading(false);
//    setForecasts(data);
//}
//# sourceMappingURL=Catalog.js.map