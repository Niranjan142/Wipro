const request = require("supertest");
const app = require("../app");

describe("Contact API", () => {

  test("Create Contact", async () => {

    const response = await request(app)
      .post("/api/contacts")
      .send({
        name: "John",
        email: "john@test.com"
      });

    expect(response.statusCode).toBe(201);

  });

});
