package dao;

import models.Reservation;

import java.util.List;
public interface ReservationDao {
    Reservation getReservationById(int id);
    List<Reservation> getAllReservations();
    void addReservation(Reservation reservation);
    void updateReservation(Reservation reservation);
    void deleteReservation(int id);
    int nombre();
}
