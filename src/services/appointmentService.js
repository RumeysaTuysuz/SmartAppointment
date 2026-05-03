import api from "./api";

export const appointmentService = {
  getAll: () => api.get("/appointments"),
  create: (data) => api.post("/appointments", data),
  delete: (id) => api.delete(`/appointments/${id}`),
};