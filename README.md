# Fashion Management System

## 👤 Author Information
*   **Student Name:** Soyte Akter Mila[cite: 1]
*   **Trainee ID:** 1294109[cite: 1]
*   **Batch:** WADA/PNTL-M/69/01[cite: 1]
*   **Course:** IsDB-BISEW Diploma in Web Application Development Using ASP.NET[cite: 1]

---

## 📝 Project Overview
The **Fashion Management System** is a web-based application built using **ASP.NET MVC** and **Entity Framework**[cite: 7]. It is designed to manage customer profiles, handle image uploads, and track product orders through a dynamic user interface[cite: 3, 7].

### 🎯 Key Features
*   **Customer CRUD:** Complete management of customer data, including names, payment dates, sizes, and delivery urgency[cite: 3, 7].
*   **Product Catalog:** A dedicated system for managing the inventory of available products[cite: 9].
*   **Dynamic Order Entry:** Users can dynamically add or remove multiple products to a single customer record using AJAX without reloading the page[cite: 2, 10].
*   **Image Processing:** Supports uploading and displaying customer profile pictures, stored in a dedicated images directory[cite: 4, 7].
*   **Asynchronous Operations:** Utilizes `jquery.unobtrusive-ajax` for seamless form submissions and partial view updates[cite: 3, 7].

---

## 🏗️ Technical Architecture

### Backend Logic (`CustomersController`)
The system manages complex data relationships through the following methods:
*   **Index:** Retrieves customers while including related order entries and product details via `FashionDbContext`[cite: 7].
*   **Create/Edit:** Processes multi-part form data, handles file uploads with unique timestamps for filenames, and manages many-to-many relationships in the `OrderEntries` table[cite: 7].
*   **Delete:** Implements a cascading logic that removes related product entries before deleting the customer record[cite: 7].

### Frontend Implementation
*   **Responsive Layout:** Built with **Bootstrap** for a mobile-friendly experience[cite: 10].
*   **Dynamic UI Logic:** jQuery handles the addition of new product rows (`#btnPlus`) and the removal of existing ones (`.btnDelete`) on the client side[cite: 10].
*   **Validation:** Uses MVC DataAnnotations for both client-side and server-side validation[cite: 3, 4].

---

## 🛠️ Tech Stack
*   **Framework:** ASP.NET MVC[cite: 7]
*   **ORM:** Entity Framework (Code First/Database First)[cite: 7]
*   **Database:** SQL Server (`FashionDbContext`)[cite: 7]
*   **Frontend:** HTML5, CSS3, Bootstrap, Font Awesome[cite: 10]
*   **Scripting:** JavaScript, jQuery, Unobtrusive AJAX[cite: 3, 10]

---

## 📂 Project Structure
*   **`Controllers/`**: Contains `CustomersController` and `ProductsController` for business logic[cite: 7, 9].
*   **`Models/ViewModels/`**: Includes `CustomerVM` for handling complex data transfer between views and controllers[cite: 3, 5].
*   **`Views/`**: 
    *   `_addNewProduct.cshtml`: A partial view for dynamic row generation[cite: 2].
    *   `Index.cshtml`: Displays the customer list in card format with nested tables for products[cite: 6].
    *   `Create/Edit/Delete.cshtml`: Forms for customer management[cite: 3, 4, 5].

---

## 🎓 Acknowledgments
This project was developed under the **IsDB-BISEW IT Scholarship Programme** at **PeopleNTech Institute of Information Technology**[cite: 1].
