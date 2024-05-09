package dao;

import models.Reservation;
import utils.ConnectionDB;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
public class ReservationDaoImp implements ReservationDao{
    private Connection cnx;
    private PreparedStatement ps;
    private ResultSet rs;

    public ReservationDaoImp() {
        cnx = ConnectionDB.getConnection();
    }
    @Override
    public Reservation getReservationById(int id) {
        String strQuery = "SELECT * FROM reservation WHERE idReservation = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                Reservation reservation = new Reservation();
                reservation.setIdReservation(rs.getInt("idReservation"));
                reservation.setUserID(rs.getInt("id_user"));
                reservation.setLivreID(rs.getInt("id_livre"));
                reservation.setDateReservation(rs.getDate("date_reservation"));
                return reservation;
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }


    @Override
    public List<Reservation> getAllReservations() {
        List<Reservation> reservations = new ArrayList<>();
        String strQuery = "SELECT * FROM reservation";
        try {
            ps = cnx.prepareStatement(strQuery);
            rs = ps.executeQuery();
            while (rs.next()) {
                Reservation reservation = new Reservation();
                reservation.setIdReservation(rs.getInt("idReservation"));
                reservation.setUserID(rs.getInt("id_user"));
                reservation.setLivreID(rs.getInt("id_livre"));
                reservation.setDateReservation(rs.getDate("date_reservation"));
                reservations.add(reservation);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return reservations;
    }

    @Override
    public void addReservation(Reservation reservation) {
        try {
            String strQuery = "INSERT INTO reservation(id_user, id_livre, date_reservation) VALUES (?, ?, ?)";
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, reservation.getUserID());
            ps.setInt(2, reservation.getLivreID());
            ps.setDate(3, new java.sql.Date(reservation.getDateReservation().getTime()));
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void updateReservation(Reservation reservation) {
        String strQuery = "UPDATE reservation SET id_user = ?, id_livre = ?, date_reservation = ? WHERE idReservation = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, reservation.getUserID());
            ps.setInt(2, reservation.getLivreID());
            ps.setDate(3, new java.sql.Date(reservation.getDateReservation().getTime()));
            ps.setInt(4, reservation.getIdReservation());
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
    @Override
    public void deleteReservation(int id) {

        String strQuery = "DELETE FROM reservation WHERE idReservation = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
}
