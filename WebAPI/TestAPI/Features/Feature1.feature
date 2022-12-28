Feature: Dropbox api file management

  Scenario: Upload file
    When I send request to upload file
    Then I should see my file uploaded

  Scenario: Get file metadata
    When I send request to get file metadata
    Then I should see my file metadata

  Scenario: Delete file
    When I send request to delete file
    Then I should not see my file



