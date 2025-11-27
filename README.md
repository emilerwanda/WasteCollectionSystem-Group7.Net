  #Waste Collection Request & Payment Management System
  #GreenTrack .NET



👥 Group Members
Name	                 ID
ISHIMWE Emile 	       26160
MUCYO David	           26019
KALIZA Natasha Peace	 24810
SHINGIRO Faisal	       26499

📌 1. Project Name

Waste Collection Request & Payment Management System (GreenTrack .NET)

📝 2. Problem Statement

Many communities struggle to manage waste collection efficiently. Current systems rely heavily on manual processes such as phone calls and physical visits, leading to:

Delayed waste pickup

Lack of payment history

Miscommunication between residents and administrators

No centralized system to track payments

Difficulty in timely truck dispatching

A digital solution is needed to streamline waste requests, payments, tracking, and dispatching operations.

🎯 3. Objectives
Main Objective

To develop a .NET-based system that enables residents to request waste collection services and make payments, while allowing administrators to manage requests and dispatch collection trucks effectively.

Specific Objectives

Allow users to register, log in, and access a personal dashboard.

Enable users to submit waste collection requests.

Allow administrators to approve or reject requests and assign trucks.

Track request status (Pending → Approved → Completed).

Generate reports for payments and collection history.

Store system data securely using SQL Server.

⚙️ 4. Requirements
A. Functional Requirements
User Side

User registration & login

Dashboard displaying profile, payments, and requests

Submit waste collection requests

View payment status (Approved / Pending / Expired)

Access payment & request history

Receive notifications for status updates

Admin Side

Admin login

Dashboard with system overview

View all waste collection requests

Approve / reject requests

Update request status (In Progress / Completed)

Assign trucks & drivers

View payment reports

Manage users (activate / deactivate)

B. Non-Functional Requirements

Usability: Simple, intuitive UI

Performance: Pages load under 2 seconds

Security: Password hashing, role-based access control

Scalability: Supports increasing users and trucks

Reliability: Real-time updates and accurate tracking

Maintainability: Built with .NET MVC / .NET Core best practices

Availability: Minimum 95% uptime

📊 5. Use Case Diagram
Actors

User

Admin

User Use Cases

Register

Login

Submit Waste Collection Request

Make Payment

View Request Status

View Payment History

Admin Use Cases

Login

View All Requests

Approve / Reject Requests

Assign Truck

Update Collection Status

View Payment Reports

Manage Users

🗄️ 6. Database Diagram (ERD)
Main Tables
1. Users

UserID (PK)

FullName

Phone

Email

PasswordHash

Role (User/Admin)

Status

2. WasteRequests

RequestID (PK)

UserID (FK)

Location

WasteType

RequestDate

Status (Pending, Approved, Completed)

3. Payments

PaymentID (PK)

RequestID (FK)

Amount

PaymentDate

PaymentStatus

4. Trucks

TruckID (PK)

PlateNumber

DriverName

Status (Available, Busy)

5. Assignments

AssignmentID (PK)

RequestID (FK)

TruckID (FK)

AssignedDate

CompletionDate

🌿Here the ERD Diagram of our database:
<img width="1310" height="719" alt="image" src="https://github.com/user-attachments/assets/5aae6d09-0c2b-4412-9b4a-54be1bbb2cf2" />


