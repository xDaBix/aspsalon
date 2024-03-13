
<?php
session_start();


if (isset($_SESSION['id'])) {
    $user_id = $_SESSION['id'];
    $user_email = $_SESSION['email'];
  
    
} else {
    header("location: login.php");
    exit();
}
?>


<!DOCTYPE html>
<html>
<head>
    <title>My Homepage</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f0f0f0;
        }

        header img {
            position: absolute;
            width: 100%;
            height: 95vh;
            object-fit: cover;
            z-index: -1; /* Move the video behind other content */
        }

        header button{
            margin-top: 0 auto;
            margin-left: 46%;
            background-color: white;
            color: black;
            padding: 10px 20px;
            font-size: 20px;
        }
        
        header {
            position: relative;
        }

        .container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 30px;
            position: relative;
        }
      
        nav {
            position: absolute;
            top: 0;
            left: 0;
            display: flex;
            justify-content: space-between;
        }


        .button {
            background-color: #ff5733;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .button:hover {
            background-color: #e63c1f;
        }

        .section {
            padding: 30px;
            text-align: center;
        }

        .photo-container {
            display: inline-block;
            margin: 30px;
        }

        .photo {
            width: 500px;
            height: 400px;
            border-radius: 2px;
            cursor: pointer;
        }

        .photo-label {
            margin-top: 10px;
        }

        .photo-link {
            text-decoration: none; /* Remove underline on the link */
            color: black; /* Set link text color to black */
        }
       

        .product-images-container {
            display: flex;
            overflow-x: auto;
        }
        .product-images-container img {
            background-color :rgb(200, 183, 152);
            padding: 10px;
            flex: 0 0 auto;
            width: 30%;
            height: 30vh;
        }

        .product-images-container :hover{

        }

    
        .row {
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .column {
        flex: 0 0 25%; /* Set a fixed width for the columns (25% for 4 columns) */
        margin: 5px;
    }

    .column img {
        width: 100%;
        height: auto; /* Maintain the image's aspect ratio */
    }


        .feedback {
            margin-top: 5%;
            margin-left: 10%;
            margin-bottom: 10%;
            background-color: #f0f0f0;
        }

       

        .footer {
            width: 90%;
            background-color: #333;
            color: #fff;
            padding: 30px 0;
        }

        .footer p {
            text-align: center;
        }

        h1{
            
        }
    </style>
</head>
<body>
    <header>
        <img src="p1.jpg" alt="bg">
        <div class="navbar">
            <?php
            include("navbar.php");
            ?>
            <!-- <button name="book">Book</button> -->
        </div>
    </header><br><BR><BR><BR><BR><BR><BR><br><br><BR><BR><BR><BR><BR><BR><br>
    <br><BR><BR><BR><BR><BR><BR><br><br><BR><BR><BR><BR><br><BR><BR><BR><BR><br>

    <div class="section services">
        <h1>Services We Offer</h1>
        <div class="photo-container">
            <a href="Fservice.php" class="photo-link">
                <img src="1.jpg" alt="Female" class="photo" id="female-photo">
                <h3>Female Service</h3>
            </a>
        </div>
        <div class="photo-container">
            <a href="Mservice.php" class="photo-link">
                <img src="2.jpg" alt="Male" class="photo" id="male-photo">
                <h3>Male Service</h3>
            </a>
        </div>
    </div>
<!-- 

    <div class="section product">
    <h1>Products</h1>
        <div class="container">
            <div class="product-images-container">
                <img src="3.jpeg" alt="Products">
                <img src="4.jpeg" alt="Products">
                <img src="6.jpeg" alt="Products">
                <img src="5.jpeg" alt="Products">
                <img src="7.jpeg" alt="Products">
                <img src="8.jpeg" alt="Products">
            </div>
        </div>
    </div>  -->

    <div class="section experts">
    <h1>Our Experts</h1><br>
        <div class="container">
            <div class="row">
                <div class="column">
                    <img src="ex3.jpg" alt="Experts">
                    <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                </div>
                <div class="column">
                <img src="ex2.webp" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                    <!-- Add the second expert image here -->
                </div>
                <div class="column">
                <img src="ex3.jpg" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                    <!-- Add the third expert image here -->
                </div>
                <div class="column">
                <img src="ex4.jpg" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                    <!-- Add the fourth expert image here -->
                </div>
            </div>
            <div class="row">
                <div class="column">
                <img src="ex5.jpeg" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                    <!-- Add the fifth expert image here -->
                </div>
                <div class="column">
                <img src="ex6.jpg" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                    <!-- Add the sixth expert image here -->
                </div>
                <div class="column">
                <img src="ex7.jpg" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
                    <!-- Add the sixth expert image here -->
                </div>
                <div class="column">
                <img src="ex8.avif" alt="Experts">
                <h2>Expert Name 3</h2>
                <p>Nulla facilisi. Cras eu quam in arcu bibendum varius. In dapibus sapien non arcu hendrerit, sed tincidunt urna convallis.</p>
               </div>
            </div>
        </div>
    </div>

<div class=" section " >
    <h1>Feedback Form</h1>
    <div class="feedback">

    <?php
    include("feedback.php");
    ?>
    </div>
</div>

    <footer class="footer">
        <?php include'footer.php'; ?>
    </footer>
</body>
</html>
