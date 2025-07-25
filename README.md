# HomeTask 7

# 🏢 CompanyService – REST API Hujjati

Ushbu servis `Practice_db` bazasidagi `Company` jadvali bilan ishlaydi. Unda kompaniya ma’lumotlarini yaratish, o‘qish, yangilash va o‘chirish imkoniyati mavjud.

---

## 🟢 GET: Barcha Company yozuvlarini olish

**🔗 Endpoint:** `GET /api/company`  
**📝 Sharti:**  
Barcha `Company` yozuvlarini ro‘yxat shaklida qaytaradi.

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 36 46" src="https://github.com/user-attachments/assets/b063b3f3-2733-45c3-8af1-5d59e86c47d5" />

---

## 🟡 POST: Yangi Company qo‘shish

**🔗 Endpoint:** `POST /api/company`  
**📝 Sharti:**  
Yangi `Company` yozuvini bazaga quyidagi ma’lumotlar bilan qo‘shadi:  
- `id`  
- `name`

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 37 11" src="https://github.com/user-attachments/assets/57cc1fb2-7479-459f-bf77-a397b455daac" />

---

## 🟠 PUT: Mavjud Company'ni yangilash

**🔗 Endpoint:** `PUT /api/company?id={id}`  
**📝 Sharti:**  
Berilgan `id` bo‘yicha mavjud kompaniyaning `name` maydonini yangilaydi.

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 37 35" src="https://github.com/user-attachments/assets/27fe59a6-8f92-4506-95f8-012745b5008f" />

---

## 🔴 DELETE: Company'ni o‘chirish

**🔗 Endpoint:** `DELETE /api/company?id={id}`  
**📝 Sharti:**  
Berilgan `id` ga teng bo‘lgan `Company` yozuvini bazadan o‘chiradi.  
Agar yozuv mavjud bo‘lmasa `null` qaytaradi.

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 48 37" src="https://github.com/user-attachments/assets/fc6702f4-4de1-4820-9836-9c784db04afe" />

---

📌 **Eslatma:**  
Ushbu servis `Practice_db` PostgreSQL ma'lumotlar bazasida ishlaydi. Ulanuvchi satri:


# 🌿 BranchService – REST API Hujjati

Ushbu servis `Practice_db` bazasidagi `Branch` jadvali bilan ishlaydi. `Branch` kompaniya filiallarini ifodalaydi. Ushbu servis orqali filiallarni qo‘shish, o‘qish, yangilash va o‘chirish mumkin.

---

## 🟡 POST: Yangi Branch qo‘shish

**🔗 Endpoint:** `POST /api/branch`  
**📝 Sharti:**  
Yangi filial (branch) quyidagi maydonlar bilan bazaga qo‘shiladi:  
- `id`  
- `location`  
- `companyId` (foreign key: `Company` jadvalidan)

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 57 34" src="https://github.com/user-attachments/assets/a2dd08c0-972f-43c8-a377-6d1d1b1f84c5" />

---

## 🟢 GET: Barcha Branch yozuvlarini olish

**🔗 Endpoint:** `GET /api/branch`  
**📝 Sharti:**  
Barcha `Branch` yozuvlarini ro‘yxat ko‘rinishida qaytaradi.

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 57 43" src="https://github.com/user-attachments/assets/4fcc7195-7817-490a-886b-49baa192786f" />

---

## 🟠 PUT: Branch ma’lumotini yangilash

**🔗 Endpoint:** `PUT /api/branch?id={id}`  
**📝 Sharti:**  
Berilgan `id` bo‘yicha filial ma’lumotlarini yangilaydi:
- `location`
- `companyId`

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 12 58 37" src="https://github.com/user-attachments/assets/520e5b1f-8a6b-4c9a-bbe9-6d6a62a86cca" />

---

## 🔴 DELETE: Branch'ni o‘chirish

**🔗 Endpoint:** `DELETE /api/branch?id={id}`  
**📝 Sharti:**  
Berilgan `id` ga teng bo‘lgan `Branch` yozuvini o‘chiradi.

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 13 00 25" src="https://github.com/user-attachments/assets/ee3dfe3d-5fae-4236-a80b-ac1df5fedc0e" />

---

📌 **Ma’lumotlar bazasi:**  
Servis quyidagi ulanish satri orqali PostgreSQL bazasiga ulanadi:


# 🏢 DepartmentService – REST API Hujjati

Ushbu servis `Practice_db` PostgreSQL bazasidagi `Department` jadvali bilan ishlaydi. `Department` — kompaniyaga tegishli bo‘limlar haqidagi ma’lumotlarni saqlaydi.

---

## 🟡 POST: Yangi Department qo‘shish

**🔗 Endpoint:** `POST /api/department`  
**📝 Sharti:**  
Yangi department quyidagi maydonlar bilan qo‘shiladi:
- `id`
- `name`
- `companyId` (foreign key bo‘lishi mumkin)

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 13 05 45" src="https://github.com/user-attachments/assets/0ae34f43-675d-4c02-867a-9ac2cd139203" />

---

## 🟢 GET: Barcha Department yozuvlarini olish

**🔗 Endpoint:** `GET /api/department`  
**📝 Sharti:**  
Bazadagi barcha `Department` yozuvlarini ro‘yxat holida qaytaradi.

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 13 06 09" src="https://github.com/user-attachments/assets/68ccd0a0-4e74-4bdd-b079-4c7bdd9ea8e0" />

---

## 🟠 PUT: Department ma’lumotlarini yangilash

**🔗 Endpoint:** `PUT /api/department?id={id}`  
**📝 Sharti:**  
Berilgan `id` bo‘yicha quyidagi ma’lumotlar yangilanadi:
- `name`
- `companyId`

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 13 06 42" src="https://github.com/user-attachments/assets/435038e8-ae91-4c22-ba5b-ce6de8f3a636" />

---

## 🔴 DELETE: Department'ni o‘chirish

**🔗 Endpoint:** `DELETE /api/department?id={id}`  
**📝 Sharti:**  
Berilgan `id` ga mos department bazadan o‘chiriladi.

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 13 07 18" src="https://github.com/user-attachments/assets/ddb4a7de-214f-4037-8a32-5f7abbf45ed5" />

---

📌 **Ulanish satri:**  
Servis quyidagi PostgreSQL ulanishi orqali ishlaydi:


# 👨‍💼 EmployeeService – REST API Hujjati

Ushbu servis `Practice_db` ma’lumotlar bazasidagi `Employee` jadvali bilan ishlaydi. Xodimlar haqidagi CRUD (Create, Read, Update, Delete) operatsiyalarini bajarish imkonini beradi.

---

## 🟡 POST: Yangi Employee qo‘shish

**🔗 Endpoint:** `POST /api/employee`  
**📝 Shartlari:**  
Quyidagi atributlar orqali yangi xodim qo‘shiladi:
- `id`
- `firstName`
- `lastName`
- `email`
- `departmentId`
- `branchId`

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 14 12 27" src="https://github.com/user-attachments/assets/2c1fd458-f60c-4a4c-8abb-f9f76eba144d" />

---

## 🟢 GET: Barcha Employee yozuvlarini olish

**🔗 Endpoint:** `GET /api/employee`  
**📝 Shartlari:**  
Xodimlar jadvalidagi barcha yozuvlar ro‘yxat holida qaytariladi.

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 14 13 16" src="https://github.com/user-attachments/assets/cfcfdb29-4abd-4218-8a23-d978c1d458ca" />

---

## 🟠 PUT: Employee ma’lumotlarini yangilash

**🔗 Endpoint:** `PUT /api/employee?id={id}`  
**📝 Shartlari:**  
Berilgan `id` bo‘yicha xodim quyidagi maydonlar asosida yangilanadi:
- `firstName`
- `lastName`
- `email`
- `departmentId`
- `branchId`

📎 **Rasm:** 

<img width="600" height="900" alt="Screenshot 2025-07-25 at 14 13 34" src="https://github.com/user-attachments/assets/47af465c-534b-4e08-b054-bc2d4c84a6cf" />

---

## 🔴 DELETE: Employee’ni o‘chirish

**🔗 Endpoint:** `DELETE /api/employee?id={id}`  
**📝 Shartlari:**  
Berilgan `id` ga mos keluvchi xodim yozuvi bazadan o‘chiriladi.

📎 **Rasm:**

<img width="600" height="900" alt="Screenshot 2025-07-25 at 14 13 43" src="https://github.com/user-attachments/assets/e0a8f7d8-034b-481e-b959-bb13542766fd" />

---

📌 **Ulanish satri (Connection String):**


