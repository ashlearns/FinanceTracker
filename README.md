# 💰 FinanceTracker

**FinanceTracker** is a Blazor-based personal finance tracking web app that helps users monitor their **cash inflows**, **outflows**, **debts**, and more — with a beautiful dashboard and rich filtering features.

---

📌 Key Features

1.  Track **Cash Inflows**, **Outflows**, and **Debts**
2. ✅ Prevent Outflows if balance is insufficient
3. ✅ Automatically clear debts when sufficient inflow is available
4. ✅ Tag transactions with **custom or existing labels**
5. ✅ Add optional **notes** to any transaction
6. ✅ Filter by **type**, **tags**, and **date range**
7. ✅ Sort transactions by date
8. ✅ Search by **title** with active filters
9. ✅ Display total number of transactions + available balance
10. ✅ Show **totals**: inflows, outflows, cleared and remaining debt
11. ✅ Highlight **highest / lowest** inflow, outflow, and debt
12. ✅ List and manage all **pending debts**
13. ✅ Filter dashboard by specific **date ranges**

---


## 🔍 Technologies Used

- **Blazor Server (.NET 7)**
- **C#**
- **Bootstrap 5**
- **Entity Framework Core**
- **MySQL**
- **JavaScript (for charts)**

---

## 📁 Project Structure

FinanceTracker/
├── Models/ # All data models (Transaction, Debt, User, etc.)
├── Services/ # Data services and business logic
├── Pages/ # Razor components like Dashboard, Transactions
├── Components/ # Reusable Blazor components
├── wwwroot/ # Static assets
├── App.razor
├── Program.cs
└── README.m