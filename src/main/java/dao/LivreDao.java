package dao;

import models.Livre;

import java.util.List;

public interface LivreDao {
    Livre getLivreById(int id);
    List<Livre> getAllLivres();
    void addLivre(Livre livre);
    void updateLivre(Livre livre);
    void deleteLivre(int id);
}
