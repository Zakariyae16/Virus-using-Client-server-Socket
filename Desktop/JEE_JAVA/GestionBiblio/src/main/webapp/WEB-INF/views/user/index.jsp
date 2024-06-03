<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="<c:url value='/fonts/icomoon/style.css'/>">
    <link rel="stylesheet" href="<c:url value='/css/owl.carousel.min.css'/>">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="<c:url value='/css/bootstrap.min.css'/>">

    <!-- Style -->
    <link rel="stylesheet" href="<c:url value='/css/style.css'/>">

    <title>Login #7</title>
    <style>
      .content {
        display: flex;
        flex-direction: column;
        justify-content: center;
        height: 100vh;
      }
      .welcome-text {
        font-size: 1.5rem;
        color: black;
      }
      footer {
        background-color: #f8f9fa;
        padding: 0px;
        text-align: center;
        position: absolute;
        bottom: 0;
        width: 100%;
        border-top: 1px solid black; /* Ligne séparatrice */
      }
      footer p {
        color: black; /* Texte noir dans le footer */
      }
    </style>
  </head>
  <body>

  <div class="content">
    <div class="container">
      <div class="row">
        <div class="col-md-6">
          <img src="<c:url value='/images/undraw_remotely_2j6y.svg'/>" alt="Image" class="img-fluid">
        </div>
        <div class="col-md-6 contents">
          <div class="row justify-content-center align-items-center">
            <div class="col-md-8 text-center">
              <div class="mb-4">
                <h3>Log In</h3>
                <p class="mb-4 welcome-text">Welcome To ismagi Library</p>
              </div>
              <form method="post" action="<c:url value='/user'/>">
                <div class="form-group first">
                  <label for="username">Username</label>
                  <input type="text" class="form-control" name="login" id="login" required="">
                </div>
                <div class="form-group last mb-4 mt-3">
                  <label for="password">Password</label>
                  <input type="password" class="form-control" name="pwd" id="pwd" required="">
                </div>

                <div class="d-flex mb-5 align-items-center">
                  <label class="control control--checkbox mb-0"><span class="caption">Remember me</span>
                    <input type="checkbox" checked="checked"/>
                    <div class="control__indicator"></div>
                  </label>
                  <span class="ml-auto"><a href="#" class="forgot-pass">Forgot Password</a></span>
                </div>

                <input type="submit" value="Log In" class="btn btn-block btn-primary">
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <footer>
    <p>Email: library@ismagi.com | Téléphone: 123-456-7890</p>
    <p>&copy; 2024 ISMAGI Library. Tous droits réservés.</p>
  </footer>

  <script src="<c:url value='/js/jquery-3.3.1.min.js'/>"></script>
  <script src="<c:url value='/js/popper.min.js'/>"></script>
  <script src="<c:url value='/js/bootstrap.min.js'/>"></script>
  <script src="<c:url value='/js/main.js'/>"></script>
  </body>
</html>
