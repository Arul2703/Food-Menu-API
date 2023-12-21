# 🍕Food Ordering System (Menu API)

The Menu API manages food items, their categories, and operations related to the online food ordering system. This API provides a robust set of functionalities to retrieve, add, update, and delete food items. 🥗🍔🍕

## Overview

This API provides functionalities related to menu items, categories, and specific operations on the food items. Below is a summary of available endpoints:

### Menu Controller
- `GET /api/Menu`: Retrieve all food items.
- `GET /api/Menu/Categories`: Retrieve all food categories.
- `GET /api/Menu/Categories/{categoryName}`: Retrieve food items by category.
- `GET /api/Menu/Price/{price}`: Retrieve food items by price.
- `GET /api/Menu/Vegan/{isVegan}`: Retrieve food items by vegan status.
- `GET /api/Menu/{id}`: Retrieve a specific food item by ID.
- `GET /api/Menu/Calories/{maxCalories}`: Retrieve food items by maximum calories.
- `GET /api/Menu/Gallery`: Retrieve gallery items.

- `POST /api/Menu`: Add a new food item.
- `PUT /api/Menu/{id}`: Update a food item by ID.
- `DELETE /api/Menu/{id}`: Delete a food item by ID.

## Installation and Setup

1. Clone this repository.
2. Ensure configurations are set correctly in the `appsettings.json` file, including necessary environment variables.
3. Install dependencies by running `dotnet restore`.
4. Run the application using your preferred method (e.g., Visual Studio, command line) with `dotnet run`.


