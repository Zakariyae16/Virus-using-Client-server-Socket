package dao;
import models.Emprunt;
import utils.ConnectionDB;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;


public class EmpruntDaoImp implements EmpruntDAO{

//}


//public class EmpruntDaoImp implements EmpruntDao {
    Connection cnx;
    PreparedStatement ps;
    ResultSet rs;

    public EmpruntDaoImp() {
        cnx = ConnectionDB.getConnection();
    }

    @Override
    public List<Emprunt> getAll() {
        List<Emprunt> emprunts = new ArrayList<>();
        String strQuery = "SELECT * FROM emprunt";
        try {
            ps = cnx.prepareStatement(strQuery);
            rs = ps.executeQuery();
            while (rs.next()) {
                Emprunt emprunt = new Emprunt();
                emprunt.setIdEmprunt(rs.getInt("idEmprunt"));
                emprunt.setUserID(rs.getInt("ID_USER"));
                emprunt.setLivreID(rs.getInt("ID_LIVRE"));
                emprunt.setDateRetour(rs.getDate("DATE_RETOUR"));
                //emprunt.setDateRetour(rs.getDate("DATE_RETOUR"));
                emprunts.add(emprunt);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return emprunts;
    }

    @Override
    public Emprunt getById(int id) {
        String strQuery = "SELECT * FROM emprunt WHERE idEmprunt = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                Emprunt emprunt = new Emprunt();
                emprunt.setIdEmprunt(rs.getInt("idEmprunt"));
                emprunt.setUserID(rs.getInt("ID_USER"));
                emprunt.setLivreID(rs.getInt("ID_LIVRE"));
                emprunt.setDateRetour(rs.getDate("DATE_RETOUR"));
                //emprunt.setDateRetour(rs.getDate("DATE_RETOUR"));
                return emprunt;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void add(Emprunt emprunt) {
        try {
            String strQuery = "INSERT INTO emprunt(ID_USER, ID_LIVRE, DATE_RETOUR) VALUES (?, ?, ?)";
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, emprunt.getUserID());
            ps.setInt(2, emprunt.getLivreID());
            ps.setDate(3, new java.sql.Date(emprunt.getDateRetour().getTime()));
            //ps.setDate(3, new java.sql.Date(emprunt.getDateRetour().getTime()));
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void update(Emprunt emprunt) {
        String strQuery = "UPDATE emprunt SET ID_USER = ?, ID_LIVRE = ?, DATE_RETOUR = ? WHERE idEmprunt = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, emprunt.getUserID());
            ps.setInt(2, emprunt.getLivreID());
            //ps.setDate(3, new java.sql.Date(emprunt.getDateRetour().getTime()));
            ps.setDate(3, new java.sql.Date(emprunt.getDateRetour().getTime()));
            //ps.setDate(3, emprunt.getDateRetour());
            ps.setInt(4, emprunt.getIdEmprunt());
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void delete(int id) {
        String strQuery = "DELETE FROM emprunt WHERE idEmprunt = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public Emprunt getEmpruntById(int id) {
        return null;
    }

    @Override
    public List<Emprunt> getAllEmprunts() {
        return null;
    }

    @Override
    public void addEmprunt(Emprunt emprunt) {

    }

    @Override
    public void updateEmprunt(Emprunt emprunt) {

    }

    @Override
    public void deleteEmprunt(int id) {

    }
}