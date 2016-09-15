// Nir Leibovitch 200315232

// surround code with an IEFE so variables & function declarations don't leak to the global object
(function () {
    // wait for DOM ready
    $(document).ready(function () {
        $.getJSON("http://api.openweathermap.org/data/2.5/weather?id=293703&units=metric&callback=?&APPID=52de0ae6d0ede6647f8fcd9ddc11b5ca", function (data) {
            $(document).ready(function () {
                $('#weatherDescription').text(data.weather.description);
                $('#weatherTemp').text(data.main.temp);
                $('#weatherHumidity').text(data.main.humidity);
            });
        });
    });
}());