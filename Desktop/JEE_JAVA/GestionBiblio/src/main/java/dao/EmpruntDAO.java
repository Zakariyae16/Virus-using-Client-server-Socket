package dao;

import models.Emprunt;

import java.util.List;

public interface EmpruntDAO {
    List<Emprunt> getAll();

    Emprunt getById(int id);

    void add(Emprunt emprunt);

    void update(Emprunt emprunt);

    void delete(int id);

    Emprunt getEmpruntById(int id);
    List<Emprunt> getAllEmprunts();
    void addEmprunt(Emprunt emprunt);
    void updateEmprunt(Emprunt emprunt);
    void deleteEmprunt(int id);
}

