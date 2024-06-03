package Controllers;

import dao.*;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import models.Livre;
import models.Reservation;
import models.Users;

import java.io.IOException;
import java.util.List;


@WebServlet(name = "admin", value = {"/admin", "/admin/livre", "/admin/livre/add", "admin/livre/edit",
        "admin/livre/update", "admin/livre/delete","admin/reservation","/admin/reservation/delete"})
public class LibrarianController extends HttpServlet {
    private final String INDEX = "/WEB-INF/views/librarian/index.jsp";

    private final String CREATE = "/WEB-INF/views/librarian/add.jsp";
    private final String LIVRE = "/WEB-INF/views/librarian/livre.jsp";

    private final String EDIT = "/WEB-INF/views/librarian/edit.jsp";

    private final String RESERVATION = "/WEB-INF/views/librarian/reservation.jsp";

    private LivreDao dao = new LivreDaoImp();

    private ReservationDao dao1 = new ReservationDaoImp();

    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String path = req.getServletPath();
        int id;
        Livre l;
        switch (path) {
            case "/admin":
                List<Livre> livres = dao.getAll();
                req.setAttribute("list", livres);
                int n1 = dao.nombre();
                int n2 = dao1.nombre();
                req.setAttribute("nombre1", n1);
                req.setAttribute("nombre2", n2);
                req.getRequestDispatcher(INDEX).forward(req, resp);
                break;
            case "/admin/livre/add":
                req.getRequestDispatcher(CREATE).forward(req, resp);
                break;
            case "/admin/livre":
                List<Livre> livres1 = dao.getAll();
                req.setAttribute("list", livres1);
                req.getRequestDispatcher(LIVRE).forward(req, resp);
                break;
            case "/admin/livre/edit":
                id = Integer.parseInt(req.getParameter("id"));
                l = dao.getById(id);
                req.setAttribute("l", l);
                req.getRequestDispatcher(EDIT).forward(req, resp);
                break;
            case "/admin/livre/delete":
                id = Integer.parseInt(req.getParameter("id"));
                dao.delete(id);
                resp.sendRedirect(req.getContextPath() + "/admin/livre");
                break;
            case "/admin/reservation":
                List<Reservation> res = dao1.getAllReservations();
                req.setAttribute("list", res);
                req.getRequestDispatcher(RESERVATION).forward(req, resp);
                break;
            case "/admin/reservation/delete":
                id = Integer.parseInt(req.getParameter("id"));
                dao1.deleteReservation(id);
                resp.sendRedirect(req.getContextPath() + "/admin/reservation");
                break;
        }

    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        Livre livre;
        Livre livre1;
        int id;
        String ISBN, titre, auteur;
        String dispo;
        ISBN = req.getParameter("ISBN");
        titre = req.getParameter("titre");
        auteur = req.getParameter("auteur");
        dispo = req.getParameter("disponible");

        boolean disponible = Boolean.parseBoolean(dispo);
        livre = new Livre(ISBN, titre, auteur);
        livre1 = new Livre(ISBN, titre, auteur, disponible);

        if (req.getServletPath().equals("/admin/livre/add")) {
            dao.add(livre);
            req.getRequestDispatcher(CREATE).forward(req, resp);
        } else if (req.getServletPath().equals("/admin/livre/edit")) {
            id = Integer.parseInt(req.getParameter("id"));
            livre1.setIdLivre(id);
            dao.update(livre1);
        }
        System.out.println("test " + req.getContextPath());
        resp.sendRedirect(req.getContextPath() + "/admin/livre");
    }
}
