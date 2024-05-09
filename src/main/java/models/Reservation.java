package models;

import java.util.Date;

public class Reservation {
    private int idReservation;
    private int userID;
    private int livreID;
    private Date dateReservation;

    // Constructor
    public Reservation(int idReservation, int userID, int livreID, Date dateReservation) {
        this.idReservation = idReservation;
        this.userID = userID;
        this.livreID = livreID;
        this.dateReservation = dateReservation;
    }

    // Getters and setters
    public int getIdReservation() {
        return idReservation;
    }

    public void setIdReservation(int idReservation) {
        this.idReservation = idReservation;
    }

    public int getUserID() {
        return userID;
    }

    public void setUserID(int userID) {
        this.userID = userID;
    }

    public int getLivreID() {
        return livreID;
    }

    public void setLivreID(int livreID) {
        this.livreID = livreID;
    }

    public Date getDateReservation() {
        return dateReservation;
    }

    public void setDateReservation(Date dateReservation) {
        this.dateReservation = dateReservation;
    }
}

