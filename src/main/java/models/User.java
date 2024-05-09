package models;

import java.util.Date;

public class User {
    private int userID;
    private String nom;
    private String prenom;
    private String username;
    private String motDePasse;
    private String role;
    private String matricule;
    private String filiere;
    private Date dateNaissance;

    // Constructor
    public User(int userID, String nom, String prenom, String username, String motDePasse, String role, String matricule, String filiere, Date dateNaissance) {
        this.userID = userID;
        this.nom = nom;
        this.prenom = prenom;
        this.username = username;
        this.motDePasse = motDePasse;
        this.role = role;
        this.matricule = matricule;
        this.filiere = filiere;
        this.dateNaissance = dateNaissance;
    }

    public User() {

    }

    // Getters and setters
    public int getUserID() {
        return userID;
    }

    public void setUserID(int userID) {
        this.userID = userID;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getPrenom() {
        return prenom;
    }

    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getMotDePasse() {
        return motDePasse;
    }

    public void setMotDePasse(String motDePasse) {
        this.motDePasse = motDePasse;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public String getMatricule() {
        return matricule;
    }

    public void setMatricule(String matricule) {
        this.matricule = matricule;
    }

    public String getFiliere() {
        return filiere;
    }

    public void setFiliere(String filiere) {
        this.filiere = filiere;
    }

    public Date getDateNaissance() {
        return dateNaissance;
    }

    public void setDateNaissance(Date dateNaissance) {
        this.dateNaissance = dateNaissance;
    }
}

