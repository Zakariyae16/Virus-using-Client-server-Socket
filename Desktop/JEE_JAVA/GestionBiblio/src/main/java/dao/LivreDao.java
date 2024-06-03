package dao;

import models.Livre;

import java.util.List;

public interface LivreDao {
    Livre getById(int id);

    int nombre();
    List<Livre> getAll();
    void add(Livre livre);
    void update(Livre livre);
    void delete(int id);
}