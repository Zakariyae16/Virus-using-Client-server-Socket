package models;

import java.util.Date;

public class Emprunt {
    private int idEmprunt;
    private int userID;
    private int livreID;
    private Date dateRetour;

    public Emprunt(int idEmprunt, int userID, int livreID, Date dateRetour) {
        this.idEmprunt = idEmprunt;
        this.userID = userID;
        this.livreID = livreID;
        this.dateRetour = dateRetour;
    }

    public Emprunt() {

    }

    public int getIdEmprunt() {
        return idEmprunt;
    }

    public void setIdEmprunt(int idEmprunt) {
        this.idEmprunt = idEmprunt;
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

    public Date getDateRetour() {
        return dateRetour;
    }

    public void setDateRetour(Date dateRetour) {
        this.dateRetour = dateRetour;
    }
}
