# ChubbBloodBank
## Sample JSON Payload

Below is an example JSON payload for adding a new donor to the Blood Bank API:


```json
[
    {
        "id": 4,
        "donorName": "Nishant Gottimukkala",
        "age": 30,
        "bloodType": "A+",
        "contactInfo": "nishantgk2004@gmail.com",
        "quantity": 3,
        "collectionDate": "2024-11-21T05:46:19.764Z",
        "expirationDate": "2024-11-21T05:46:19.764Z",
        "status": "Available"
    }
]

```

---

# Blood Bank Management API

The **Blood Bank Management API** provides functionality to manage blood donors' entries, including operations to create, update, retrieve, and delete donor information, as well as search and filter data.

---

## Features

- **CRUD Operations**: Add, retrieve, update, and delete blood donor records.
- **Search**: Filter donors by blood type, status, or name.
- **Pagination**: Retrieve data in paginated format for large datasets.
- **Validation**: Ensures data integrity, such as valid blood types and statuses.

---

## Model: BloodBankEntry

The **Donor** model represents the structure of a blood donor's entry and includes the following attributes:

| Attribute         | Description                                                |
|-------------------|------------------------------------------------------------|
| **Id**            | Unique identifier (auto-generated).                        |
| **DonorName**     | Name of the donor.                                         |
| **Age**           | Age of the donor.                                          |
| **BloodType**     | Blood type of the donor (e.g., O+, A-, B+).                |
| **ContactInfo**   | Contact details (e.g., email id).                      |
| **Quantity**      | Amount of blood donated (in ml).                           |
| **CollectionDate**| Date when the blood was collected.                         |
| **ExpirationDate**| Expiration date for the blood unit        |
| **Status**        | Current status of the blood (Available, Requested, Expired). |

---


## API Endpoints

### **1. CRUD Endpoints**

#### Retrieve All Donors
- **Endpoint**: `GET /api/bloodbank`
- **Description**: Fetches all blood donor records.
- **Response**: A list of all donor entries.

#### Retrieve Donor by ID
- **Endpoint**: `GET /api/bloodbank/{id}`
- **Description**: Fetches a specific donor record by its unique ID.
- **Request Parameters**:
  - `id` (path parameter): The ID of the donor.
- **Response**: The donor entry if it exists, or `404 Not Found` if it doesn’t.

#### Add a New Donor
- **Endpoint**: `POST /api/bloodbank`
- **Description**: Adds a new donor record to the system.
- **Response**: The created donor entry.

#### Update Donor by ID
- **Endpoint**: `PUT /api/bloodbank/{id}`
- **Description**: Updates the details of an existing donor.
- **Request Parameters**:
  - `id` (path parameter): The ID of the donor to update.
- **Response**: `204 No Content` if successful, or `404 Not Found` if the donor does not exist.

#### Delete Donor by ID
- **Endpoint**: `DELETE /api/bloodbank/{id}`
- **Description**: Deletes a donor record from the system.
- **Request Parameters**:
  - `id` (path parameter): The ID of the donor to delete.
- **Response**: `204 No Content` if successful, or `404 Not Found` if the donor does not exist.

---

### **2. Search Endpoints**

#### Search by Blood Type
- **Endpoint**: `GET /api/bloodbank/search/type/{bloodType}`
- **Description**: Fetches all donor records that match the specified blood type.
- **Request Parameters**:
  - `bloodType` (path parameter): The blood type to filter by (e.g., `A+`, `O-`).
- **Response**: A list of matching donor entries, or `404 Not Found` if no matches exist.

#### Search by Status
- **Endpoint**: `GET /api/bloodbank/search/status/{status}`
- **Description**: Fetches all donor records that match the specified status.
- **Allowed Values**: `"Available"`, `"Requested"`.
- **Request Parameters**:
  - `status` (path parameter): The status to filter by.
- **Response**: A list of matching donor entries, or `404 Not Found` if no matches exist.

#### Search by Donor Name
- **Endpoint**: `GET /api/bloodbank/search/donorName/{donorName}`
- **Description**: Fetches all donor records that contain the specified name.
- **Request Parameters**:
  - `donorName` (path parameter): The partial or full name to filter by.
- **Response**: A list of matching donor entries, or `404 Not Found` if no matches exist.

---

### **3. Pagination Endpoint**

#### Paginated Data
- **Endpoint**: `GET /api/bloodbank/page`
- **Description**: Fetches a paginated list of donor records.
- **Request Parameters**:
  - `pageNumber` (query parameter, required): The page number to retrieve (must be greater than `0`).
  - `pageSize` (query parameter, required): The number of records per page.
- **Response**:
  - A paginated list of donor entries if available.
  - `404 Not Found` if the requested page contains no records.

---

## Example Usage

### Retrieve All Donors
```bash
GET http://localhost:5201/api/bloodbank
```

### Search by Blood Type
```bash
GET http://localhost:5201/api/bloodbank/search/type/A+
```

### Paginated Data
```bash
GET http://localhost:5201/api/bloodbank/page?pageNumber=1&pageSize=5
```

---

Feel free to copy this file into your repository’s `README.md` and adjust it as needed! Let me know if you need further refinements.
