# Lift Log API

The **Lift Log API** is a RESTful application for managing gym activity records. This API allows users to track their progress in weight training, log exercises, and maintain a detailed history of their activities.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Endpoints](#endpoints)

## Features

- Registration and retrieval of exercises, workouts, sets, and repetitions
- Querying activity history
- User authentication

## Technologies

- C#
- .NET
- SQL Server
- Entity Framework Core

## Endpoints

### Muscles
- `GET /muscle`: Lists all muscle groups.

### Exercises
- `GET /exercise`: Lists all exercises.
- `GET /exercise/:id`: Retrieves the exercise by ID.
- `GET /exercise/muscle/:id`: Lists exercises based on the muscle group.

### Workouts
- `POST /training`: Creates a new workout for the user.
- `GET /training/:id`: Retrieves the workout by ID.
- `GET /training/user/:id`: Lists workouts by user ID.
- `POST /training/exercise`: Adds an existing exercise to an existing workout.
- `POST /training/exercise/:id`: Lists exercises from a workout.

### Authentication
- `POST /auth/register`: Allows the registration of a new user.
- `POST /auth/login`: Allows user login.
