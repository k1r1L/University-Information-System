# Uis
 University Information System
## Idea
An application that stores information about teachers (their courses and their enrolled students) and about 
students (their mandatory and open courses).
## Design
The application is split into four parts
* Main area
    * Guests are not allowed into the system
    * Direct login provided
* Admin area
    * Admins can register users
    * Admins can manage all courses (All CRUD operations)
    * Admins can attach courses to students
    * Admins can view all users and reset their passwords
* Teacher area
    * Teachers can manage their courses
    * Teachers can grade their students
* Student area
    * Students can view their mandatory courses
    * Students can add open courses to their program
* Additional
    * Each user has a profile page
    * Users can send each other messages
