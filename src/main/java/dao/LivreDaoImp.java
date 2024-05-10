package dao;

import models.Livre;
import utils.ConnectionDB;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
public class LivreDaoImp implements LivreDao {
    private Connection cnx;
    private PreparedStatement ps;
    private ResultSet rs;

    public LivreDaoImp() {
        cnx = ConnectionDB.getConnection();
    }
    @Override
    public Livre getById(int id) {
        String strQuery = "SELECT * FROM livres WHERE ID_LIVRE = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                Livre livre = new Livre();
                livre.setIdLivre(rs.getInt("ID_LIVRE"));
                livre.setIsbn(rs.getString("ISBN"));
                livre.setTitre(rs.getString("TITRE"));
                livre.setAuteur(rs.getString("AUTEUR"));
                livre.setEstDisponible(rs.getBoolean("EST_DISPONIBLE"));
                return livre;
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }

    @Override
    public List<Livre> getAll() {
        List<Livre> livres = new ArrayList<>();
        String strQuery = "SELECT * FROM livres";
        try {
            ps = cnx.prepareStatement(strQuery);
            rs = ps.executeQuery();
            while (rs.next()) {
                Livre livre = new Livre();
                livre.setIdLivre(rs.getInt("ID_LIVRE"));
                livre.setIsbn(rs.getString("ISBN"));
                livre.setTitre(rs.getString("TITRE"));
                livre.setAuteur(rs.getString("AUTEUR"));
                livre.setEstDisponible(rs.getBoolean("EST_DISPONIBLE"));
                livres.add(livre);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return livres;
    }

    @Override
    public void add(Livre livre) {
        try {
            String strQuery = "INSERT INTO livres(ISBN, TITRE, AUTEUR, EST_DISPONIBLE) VALUES (?, ?, ?, ?)";
            ps = cnx.prepareStatement(strQuery);
            ps.setString(1, livre.getIsbn());
            ps.setString(2, livre.getTitre());
            ps.setString(3, livre.getAuteur());
            ps.setBoolean(4, livre.isEstDisponible());
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void update(Livre livre) {
        String strQuery = "UPDATE livres SET ISBN = ?, TITRE = ?, AUTEUR = ?, EST_DISPONIBLE = ? WHERE ID_LIVRE = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setString(1, livre.getIsbn());
            ps.setString(2, livre.getTitre());
            ps.setString(3, livre.getAuteur());
            ps.setBoolean(4, livre.isEstDisponible());
            ps.setInt(5, livre.getIdLivre());
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void delete(int id) {
        String strQuery = "DELETE FROM livres WHERE ID_LIVRE = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
}
