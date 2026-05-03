import { useEffect, useState } from "react";
import { appointmentService } from "./services/appointmentService";

function App() {
  // 🔹 Liste state
  const [appointments, setAppointments] = useState([]);

  // 🔹 Form state
  const [form, setForm] = useState({
    fullName: "",
    email: "",
    appointmentDate: "",
    description: ""
  });

  // 🔹 VERİYİ ÇEK
  const loadData = async () => {
    const res = await appointmentService.getAll();
    setAppointments(res.data.data); // ApiResponse -> data içinde data var
  };

  useEffect(() => {
    loadData();
  }, []);

  // 🔹 INPUT DEĞİŞİMİ
  const handleChange = (e) => {
    setForm({
      ...form,
      [e.target.name]: e.target.value
    });
  };

  // 🔹 CREATE (EKLEME)
  const handleCreate = async (e) => {
  e.preventDefault();

  try {
    const fixedData = {
      ...form,
      appointmentDate: new Date(form.appointmentDate).toISOString()
    };

    await appointmentService.create(fixedData);

    setForm({
      fullName: "",
      email: "",
      appointmentDate: "",
      description: ""
    });

    loadData();
  } catch (err) {
    console.log(err.response?.data || err);
  }
};

  // 🔹 DELETE (SİLME)
  const handleDelete = async (id) => {
    await appointmentService.delete(id);
    loadData();
  };

  return (
    <div style={{ padding: "20px" }}>
      <h1>Smart Appointment System</h1>

      {/* 🟢 FORM */}
      <form onSubmit={handleCreate} style={{ marginBottom: "20px" }}>
        <input
          name="fullName"
          placeholder="Full Name"
          value={form.fullName}
          onChange={handleChange}
        />

        <br />

        <input
          name="email"
          placeholder="Email"
          value={form.email}
          onChange={handleChange}
        />

        <br />

        <input
          name="appointmentDate"
          type="datetime-local"
          value={form.appointmentDate}
          onChange={handleChange}
        />

        <br />

        <input
          name="description"
          placeholder="Description"
          value={form.description}
          onChange={handleChange}
        />

        <br />

        <button type="submit">Create Appointment</button>
      </form>

      <hr />

      {/* 🟢 LİSTE */}
      {appointments.map((a) => (
        <div key={a.id} style={{ marginBottom: "15px" }}>
          <b>{a.fullName}</b>
          <div>{a.email}</div>
          <div>{new Date(a.appointmentDate).toLocaleString()}</div>
          <div>{a.description}</div>

          <button onClick={() => handleDelete(a.id)}>
            Delete
          </button>
        </div>
      ))}
    </div>
  );
}

export default App;