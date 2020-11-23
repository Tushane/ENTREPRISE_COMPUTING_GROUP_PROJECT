<%@ Page Title = "Product" Language="C#" enableEventValidation="true" MasterPageFile = "~/Master.master"  AutoEventWireup = "true" CodeBehind = "Product.aspx.cs" Inherits="eStore.Product" %>

<asp:Content ID="body" ContentPlaceHolderID="bodyContent" runat="server">
  <div class="featured-product product">
            <div class="container-fluid">
                <div class="section-header">
                    <h1>Product</h1>
                </div>
                <div class="row align-items-center product-slider product-slider-4">
                    
                    <div class="col-lg-12">
                        <div class="product-item">
                            <div class="product-title">
                                <a href="#">Product Name</a>
                            </div>
                            <div class="product-image">
                                <a href="product-detail.html">
                                    <img src="img/product-1.jpg" alt="Product Image">
                                </a>
                                <div class="product-action">
                                    <a href="#"><i class="fa fa-cart-plus"></i></a>
                                    <a href="#"><i class="fa fa-search"></i></a>
                                </div>
                            </div>
                            <div class="product-price">
                                <h3><span>$</span>99</h3>
                                <a class="btn" href=""><i class="fa fa-shopping-cart"></i>Buy Now</a>
                            </div>
                        </div>
                    </div>
                    
                    
                </div>
            </div>
        </div>
</asp:Content>
