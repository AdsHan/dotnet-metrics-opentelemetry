﻿using MetricsOpenTelemetry.API.Common;

namespace MetricsOpenTelemetry.API.Application.Messages.Commands;

public class CreateProductCommand(string title, string description, double price, int quantity) : Command
{
    public string Title => title;
    public string Description => description;
    public double Price => price;
    public int Quantity => quantity;
}
