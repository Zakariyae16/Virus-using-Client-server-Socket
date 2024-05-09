package dao;

import models.User;

import java.util.List;
import models.User;
import utils.ConnectionDB;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;


public class UserDaoImp implements UserDao{
    private Connection cnx;
    private PreparedStatement ps;
    private ResultSet rs;

    public UserDaoImp() {
        cnx = ConnectionDB.getConnection();
    }
    @Override
    public User getUserById(int id) {
        String strQuery = "SELECT * FROM users WHERE ID_USER = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                User user = new User();
                user.setUserID(rs.getInt("ID_USER"));
                user.setNom(rs.getString("NOM"));
                user.setPrenom(rs.getString("PRENOM"));
                user.setUsername(rs.getString("USERNAME"));
                user.setMotDePasse(rs.getString("MOT_DE_PASSE"));
                user.setRole(rs.getString("ROLE"));
                user.setMatricule(rs.getString("MATRICULE"));
                user.setFiliere(rs.getString("FILIERE"));
                // Assuming DATE_NAISSANCE is stored as a Date in the database
                user.setDateNaissance(rs.getDate("DATE_NAISSANCE"));
                return user;
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return null;
    }

    @Override
    public List<User> getAllUsers() {
        List<User> users = new ArrayList<>();
        String strQuery = "SELECT * FROM users";
        try {
            ps = cnx.prepareStatement(strQuery);
            rs = ps.executeQuery();
            while (rs.next()) {
                User user = new User();
                user.setUserID(rs.getInt("ID_USER"));
                user.setNom(rs.getString("NOM"));
                user.setPrenom(rs.getString("PRENOM"));
                user.setUsername(rs.getString("USERNAME"));
                user.setMotDePasse(rs.getString("MOT_DE_PASSE"));
                user.setRole(rs.getString("ROLE"));
                user.setMatricule(rs.getString("MATRICULE"));
                user.setFiliere(rs.getString("FILIERE"));
                // Assuming DATE_NAISSANCE is stored as a Date in the database
                user.setDateNaissance(rs.getDate("DATE_NAISSANCE"));
                users.add(user);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return users;
    }

    @Override
    public void addUser(User user) {
        try {
            String strQuery = "INSERT INTO users(NOM, PRENOM, USERNAME, MOT_DE_PASSE, ROLE, MATRICULE, FILIERE, DATE_NAISSANCE) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            ps = cnx.prepareStatement(strQuery);
            ps.setString(1, user.getNom());
            ps.setString(2, user.getPrenom());
            ps.setString(3, user.getUsername());
            ps.setString(4, user.getMotDePasse());
            ps.setString(5, user.getRole());
            ps.setString(6, user.getMatricule());
            ps.setString(7, user.getFiliere());
            // Assuming DATE_NAISSANCE is stored as a Date in the database
            ps.setDate(8, new java.sql.Date(user.getDateNaissance().getTime()));
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
    @Override
    public void updateUser(User user) {
        String strQuery = "UPDATE users SET NOM = ?, PRENOM = ?, USERNAME = ?, MOT_DE_PASSE = ?, ROLE = ?, MATRICULE = ?, FILIERE = ?, DATE_NAISSANCE = ? WHERE ID_USER = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setString(1, user.getNom());
            ps.setString(2, user.getPrenom());
            ps.setString(3, user.getUsername());
            ps.setString(4, user.getMotDePasse());
            ps.setString(5, user.getRole());
            ps.setString(6, user.getMatricule());
            ps.setString(7, user.getFiliere());
            // Assuming DATE_NAISSANCE is stored as a Date in the database
            ps.setDate(8, new java.sql.Date(user.getDateNaissance().getTime()));
            ps.setInt(9, user.getUserID());
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
    @Override
    public void deleteUser(int id) {
        String strQuery = "DELETE FROM users WHERE ID_USER = ?";
        try {
            ps = cnx.prepareStatement(strQuery);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (SQLException e) {
            throw new RuntimeException(e);
        }
    }
}
