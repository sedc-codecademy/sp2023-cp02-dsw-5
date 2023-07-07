function GetByCategory(category){
    switch(category){
        case "smart_lights":
            return [
                {
                  "id": 1,
                  "name": "Smart Light Bulb",
                  "description": "Control your lights from anywhere with this smart light bulb.",
                  "price": 19.99,
                  "imageUrl": "https://example.com/images/smart-light.jpg",
                  "category": "light"
                },
                {
                  "id": 5,
                  "name": "Smart LED Strip",
                  "description": "Add ambiance to any room with this versatile smart LED strip.",
                  "price": 39.99,
                  "imageUrl": "https://example.com/images/smart-led-strip.jpg",
                  "category": "light"
                },
                {
                  "id": 10,
                  "name": "Smart Ceiling Light",
                  "description": "Control the brightness and color of this smart ceiling light with your voice or phone.",
                  "price": 79.99,
                  "imageUrl": "https://example.com/images/smart-ceiling-light.jpg",
                  "category": "light"
                },
                {
                  "id": 15,
                  "name": "Smart Desk Lamp",
                  "description": "Adjust the brightness and color temperature of this smart desk lamp with your voice or phone.",
                  "price": 49.99,
                  "imageUrl": "https://example.com/images/smart-desk-lamp.jpg",
                  "category": "light"
                }
              ];
        case "smart_plugs":
            return  [
                {
                  "id": 2,
                  "name": "Smart Plug",
                  "description": "Turn any device into a smart device with this easy-to-use smart plug.",
                  "price": 24.99,
                  "imageUrl": "https://example.com/images/smart-plug.jpg",
                  "category": "plug"
                },
                {
                  "id": 6,
                  "name": "Smart Power Strip",
                  "description": "Control multiple devices with this smart power strip, which features individual outlets for each device.",
                  "price": 49.99,
                  "imageUrl": "https://example.com/images/smart-power-strip.jpg",
                  "category": "plug"
                },
                {
                  "id": 11,
                  "name": "Smart Outlet",
                  "description": "This smart outlet is easy to install and allows you to control any device with your voice or phone.",
                  "price": 29.99,
                  "imageUrl": "https://example.com/images/smart-outlet.jpg",
                  "category": "plug"
                },
                {
                  "id": 16,
                  "name": "Smart Switch",
                  "description": "Replace your existing light switch with this smart switch and control your lights with your voice or phone.",
                  "price": 39.99,
                  "imageUrl": "https://example.com/images/smart-switch.jpg",
                  "category": "plug"
                }
              ]
        case "smart_speaker":
            return [
                {
                  "id": 5,
                  "name": "Smart Speaker with Alexa",
                  "description": "This smart speaker with Alexa allows you to control your smart home devices, play music, and get information with your voice.",
                  "price": 99.99,
                  "imageUrl": "https://example.com/images/smart-speaker-alexa.jpg",
                  "category": "speaker"
                },
                {
                  "id": 9,
                  "name": "Smart Soundbar",
                  "description": "Improve your home theater experience with this smart soundbar, which features voice control and streaming capabilities.",
                  "price": 249.99,
                  "imageUrl": "https://example.com/images/smart-soundbar.jpg",
                  "category": "speaker"
                },
                {
                  "id": 14,
                  "name": "Smart Portable Speaker",
                  "description": "Take your music with you wherever you go with this smart portable speaker, which features a waterproof design and voice control.",
                  "price": 149.99,
                  "imageUrl": "https://example.com/images/smart-portable-speaker.jpg",
                  "category": "speaker"
                },
                {
                  "id": 19,
                  "name": "Smart Bookshelf Speaker",
                  "description": "Enjoy high-quality sound and voice control with these smart bookshelf speakers, which can be integrated with your smart home system.",
                  "price": 299.99,
                  "imageUrl": "https://example.com/images/smart-bookshelf-speaker.jpg",
                  "category": "speaker"
                }
              ];
        case "smart_thermostats":
            return [
                {
                  "id": 3,
                  "name": "Smart Thermostat",
                  "description": "Reduce your energy bills and control your home's temperature with this smart thermostat.",
                  "price": 149.99,
                  "imageUrl": "https://example.com/images/smart-thermostat.jpg",
                  "category": "thermostat"
                },
                {
                  "id": 7,
                  "name": "Smart Room Sensor",
                  "description": "This smart room sensor works with your smart thermostat to adjust the temperature based on the room's occupancy and temperature.",
                  "price": 39.99,
                  "imageUrl": "https://example.com/images/smart-room-sensor.jpg",
                  "category": "thermostat"
                },
                {
                  "id": 12,
                  "name": "Smart Heating Panel",
                  "description": "This smart heating panel can be controlled with your voice or phone, and features a sleek and modern design.",
                  "price": 199.99,
                  "imageUrl": "https://example.com/images/smart-heating-panel.jpg",
                  "category": "thermostat"
                },
                {
                  "id": 17,
                  "name": "Smart Air Conditioner",
                  "description": "Control your air conditioner with your voice or phone and set schedules to save energy with this smart air conditioner.",
                  "price": 349.99,
                  "imageUrl": "https://example.com/images/smart-air-conditioner.jpg",
                  "category": "thermostat"
                }
              ];

        case "wifi_extenders":
            return [
                {
                  "id": 4,
                  "name": "Smart WiFi Extender",
                  "description": "Extend your WiFi coverage to every corner of your home with this smart WiFi extender.",
                  "price": 49.99,
                  "imageUrl": "https://example.com/images/smart-wifi-extender.jpg",
                  "category": "wifi"
                },
                {
                  "id": 8,
                  "name": "Smart Router",
                  "description": "Control your home network with this smart router, which features parental controls and easy setup.",
                  "price": 99.99,
                  "imageUrl": "https://example.com/images/smart-router.jpg",
                  "category": "wifi"
                },
                {
                  "id": 13,
                  "name": "Smart Mesh WiFi System",
                  "description": "Eliminate dead zones and improve your WiFi coverage with this smart mesh WiFi system.",
                  "price": 249.99,
                  "imageUrl": "https://example.com/images/smart-mesh-wifi-system.jpg",
                  "category": "wifi"
                },
                {
                  "id": 18,
                  "name": "Smart Network Switch",
                  "description": "This smart network switch allows you to prioritize traffic and manage your network from anywhere.",
                  "price": 149.99,
                  "imageUrl": "https://example.com/images/smart-network-switch.jpg",
                  "category": "wifi"
                }
              ];
        default:
            return `There is no category named ${category}`;
    }
}

function SearchByKeyword(keyword){
    if(keyword.toLowerCase() === "wifi"){
        return [
            {
              "id": 4,
              "name": "Smart WiFi Extender",
              "description": "Extend your WiFi coverage to every corner of your home with this smart WiFi extender.",
              "price": 49.99,
              "imageUrl": "https://m.media-amazon.com/images/I/51KuIMhavQL._AC_SX679_.jpg",
              "category": "wifi"
            },
            {
              "id": 8,
              "name": "Smart Router",
              "description": "Control your home network with this smart router, which features parental controls and easy setup.",
              "price": 99.99,
              "imageUrl": "https://m.media-amazon.com/images/I/51KuIMhavQL._AC_SX679_.jpg",
              "category": "wifi"
            },
            {
              "id": 13,
              "name": "Smart Mesh WiFi System",
              "description": "Eliminate dead zones and improve your WiFi coverage with this smart mesh WiFi system.",
              "price": 249.99,
              "imageUrl": "https://m.media-amazon.com/images/I/51KuIMhavQL._AC_SX679_.jpg",
              "category": "wifi"
            },
            {
              "id": 18,
              "name": "Smart Network Switch",
              "description": "This smart network switch allows you to prioritize traffic and manage your network from anywhere.",
              "price": 149.99,
              "imageUrl": "https://m.media-amazon.com/images/I/51KuIMhavQL._AC_SX679_.jpg",
              "category": "wifi"
            }
        ];
    }
    return [];
}

function GetById(id){
    if(id === 1){
        return {
            "id": 3,
            "name": "Smart Thermostat",
            "description": "Reduce your energy bills and control your home's temperature with this smart thermostat.",
            "price": 149.99,
            "imageUrl": "https://m.media-amazon.com/images/I/51E3wMYvxHL._AC_SX522_.jpg",
            "category": "thermostat"
        };
    }
    return null;
}

export { GetByCategory, SearchByKeyword, GetById };