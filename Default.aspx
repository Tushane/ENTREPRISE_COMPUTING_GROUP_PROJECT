<%@ Page Title = "Home" Language="C#" enableEventValidation="true" MasterPageFile = "~/Master.master"  AutoEventWireup = "true" CodeBehind = "Default.aspx.cs" Inherits="eStore.Default" %>

<asp:Content ID="body" ContentPlaceHolderID="bodyContent" runat="server">
    <!-- Main Slider Start -->
        <div class="header">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-3">
                        <nav class="navbar bg-light">
                            <ul class="navbar-nav">
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-home"></i>Home</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-shopping-bag"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-plus-square"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-female"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-child"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-tshirt"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-mobile-alt"></i></a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#"><i class="fa fa-microchip"></i></a>
                                </li>
                            </ul>
                        </nav>
                    </div>
                    <div class="col-md-6">
                        <div class="header-slider normal-slider">
                            <div class="header-slider-item">
                                <img src="img/slider-1.jpg" alt="Slider Image" />
                                <div class="header-slider-caption">
                                    <p>Some text goes here that describes the image</p>
                                    <a class="btn" href=""><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>
                            <div class="header-slider-item">
                                <img src="img/slider-2.jpg" alt="Slider Image" />
                                <div class="header-slider-caption">
                                    <p>Some text goes here that describes the image</p>
                                    <a class="btn" href=""><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>
                            <div class="header-slider-item">
                                <img src="img/slider-3.jpg" alt="Slider Image" />
                                <div class="header-slider-caption">
                                    <p>Some text goes here that describes the image</p>
                                    <a class="btn" href=""><i class="fa fa-shopping-cart"></i>Shop Now</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="header-img">
                            <div class="img-item">
                                <img src="img/category-1.jpg" />
                                <a class="img-text" href="">
                                    <p>Some text goes here that describes the image</p>
                                </a>
                            </div>
                            <div class="img-item">
                                <img src="img/category-2.jpg" />
                                <a class="img-text" href="">
                                    <p>Some text goes here that describes the image</p>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>  
        <!-- Main Slider End --> 

</asp:Content>