package models;

public class Livre {
    private int idLivre;
    private String isbn;
    private String titre;
    private String auteur;
    private boolean estDisponible;

    // Constructor
    public Livre(int idLivre, String isbn, String titre, String auteur, boolean estDisponible) {
        this.idLivre = idLivre;
        this.isbn = isbn;
        this.titre = titre;
        this.auteur = auteur;
        this.estDisponible = estDisponible;
    }

    public Livre() {

    }

    // Getters and setters
    public int getIdLivre() {
        return idLivre;
    }

    public void setIdLivre(int idLivre) {
        this.idLivre = idLivre;
    }

    public String getIsbn() {
        return isbn;
    }

    public void setIsbn(String isbn) {
        this.isbn = isbn;
    }

    public String getTitre() {
        return titre;
    }

    public void setTitre(String titre) {
        this.titre = titre;
    }

    public String getAuteur() {
        return auteur;
    }

    public void setAuteur(String auteur) {
        this.auteur = auteur;
    }

    public boolean isEstDisponible() {
        return estDisponible;
    }

    public void setEstDisponible(boolean estDisponible) {
        this.estDisponible = estDisponible;
    }
}

