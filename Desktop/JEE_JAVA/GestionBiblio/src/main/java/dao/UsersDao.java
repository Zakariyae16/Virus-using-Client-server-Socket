package dao;

import models.Users;

import java.util.List;

public interface UsersDao {

    Users getByLogin(String login, String pwd);
    Users getUserById(int id);
    List<Users> getAllUsers();
    void addUser(Users user);
    void updateUser(Users user);
    void deleteUser(int id);

}
