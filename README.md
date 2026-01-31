# 🏢 Meeting Room Booking API

A simple **ASP.NET Core Web API** for managing meeting rooms and booking time slots without conflicts. This project demonstrates clean API design, validation rules, and proper database relationships using **Entity Framework Core**.

---

## 🚀 Features

### Room Management

* Create meeting rooms
* Get all rooms
* Get room by ID
* Delete room (blocked if future bookings exist)

### Booking Management

* Create booking (room assigned automatically by backend)
* Prevent overlapping bookings
* Get booking by ID
* Get bookings by room
* Cancel booking

### Business Rules

* ❌ No overlapping bookings for the same room
* ⏰ StartTime must be before EndTime
* ⛔ Cannot book meetings in the past
* 🗑 Room cannot be deleted if it has future bookings

---

## 🛠 Tech Stack

* **ASP.NET Core 8 Web API**
* **Entity Framework Core**
* **SQL Server**
* **Swagger / OpenAPI**

---

## 📂 Project Structure

```
MeetingRoomBookingApi
│
├── Controllers
│   ├── RoomsController.cs
│   └── BookingController.cs
│
├── Domain
│   ├── Room.cs
│   └── Booking.cs
│
├── DTOs
│   └── BookingCreateRequest.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

## ⚙️ Setup Instructions

### Prerequisites

* .NET 9 SDK
* SQL Server
* Visual Studio 2026

### Steps

1. **Clone repository**

```bash
git clone https://github.com/RakeshKalsariya/Meeting-Room-Booking-API
```

2. **Update connection string** in `appsettings.json`

```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=XIT037\\MSSQLSERVER2022;Database=Room_Metting;User ID=test.practical;Password=pass@word1;TrustServerCertificate=True;"
  }
```

3. **Run migrations**

```powershell
Add-Migration InitialCreate
Update-Database
```

4. **Run the project**

```bash
dotnet run
```

5. Open Swagger UI

```
https://localhost:{port}/swagger/index.html
```

---

## 🔗 API Endpoints

### Rooms

| Method | Endpoint        | Description    |
| ------ | --------------- | -------------- |
| POST   | /api/rooms      | Create room    |
| GET    | /api/rooms      | Get all rooms  |
| GET    | /api/rooms/{id} | Get room by ID |
| DELETE | /api/rooms/{id} | Delete room    |

### Bookings

| Method | Endpoint                    | Description          |
| ------ | --------------------------- | -------------------- |
| POST   | /api/bookings               | Create booking       |
| GET    | /api/bookings/{id}          | Get booking by ID    |
| GET    | /api/bookings/room/{roomId} | Get bookings by room |
| DELETE | /api/bookings/{id}          | Cancel booking       |


## 🧠 Assumptions

* User authentication is out of scope
* Timezone handled using UTC
* One booking belongs to one room
* One room can have multiple bookings

---

## 📖 Swagger

Swagger is enabled by default and can be accessed at:

```
/swagger
```

Use Swagger UI to test all APIs.

---

## 👨‍💻 Author

**Rakesh Kalsariya**
Backend Developer – ASP.NET Core

---

## ⭐ Notes

This project is ideal for:

* Machine coding rounds
* Backend interviews
* Clean architecture practice

Feel free to fork, improve, and use it for learning 🚀
